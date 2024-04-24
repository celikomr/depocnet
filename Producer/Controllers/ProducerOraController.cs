using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Producer.Controllers;

[Route("[controller]")]
public class ProducerOraController(OraDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] QuoteOra quote)
    {
        try
        {
            quote.Id = GetNextSequenceValue(dbContext, "SEQ_PK_QUOTE", "MAE_CORE");
            dbContext.Quotes.Add(quote);
            dbContext.SaveChanges();
            return StatusCode(201, quote.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut]
    public IActionResult Update([FromBody] QuoteOra quote)
    {
        try
        {
            QuoteOra? updatedProduct = dbContext.Quotes.FirstOrDefault(x => x.Id == quote.Id);
            if (updatedProduct != null)
            {
                updatedProduct.ProductId = quote.ProductId;
                updatedProduct.Price = quote.Price;
                dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] int id)
    {
        try
        {
            QuoteOra? quote = dbContext.Quotes.FirstOrDefault(x => x.Id == id);
            if (quote != null)
            {
                dbContext.Quotes.Remove(quote);
                dbContext.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public IActionResult Read([FromQuery] int id)
    {
        try
        {
            QuoteOra? quote = dbContext.Quotes.FirstOrDefault(x => x.Id == id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    private static int GetNextSequenceValue(DbContext context, string name, string? schema = null)
    {
        var sqlGenerator = context.GetService<IUpdateSqlGenerator>();
        var sql = sqlGenerator.GenerateNextSequenceValueOperation(name, schema ?? context.Model.GetDefaultSchema());
        var rawCommandBuilder = context.GetService<IRawSqlCommandBuilder>();
        var command = rawCommandBuilder.Build(sql);
        var connection = context.GetService<IRelationalConnection>();
        var logger = context.GetService<IDiagnosticsLogger<DbLoggerCategory.Database.Command>>();
        var parameters = new RelationalCommandParameterObject(connection, null, null, context, (IRelationalCommandDiagnosticsLogger?)logger);
        var result = command.ExecuteScalar(parameters);
        return Convert.ToInt32(result, CultureInfo.InvariantCulture);
    }
}
