using Microsoft.AspNetCore.Mvc;

namespace Producer.Controllers;

[Route("[controller]")]
public class ProducerPgController(PgDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] Quote quote)
    {
        try
        {
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
    public IActionResult Update([FromBody] Quote quote)
    {
        try
        {
            Quote? updatedProduct = dbContext.Quotes.FirstOrDefault(x => x.Id == quote.Id);
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
            Quote? quote = dbContext.Quotes.FirstOrDefault(x => x.Id == id);
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
            Quote? quote = dbContext.Quotes.FirstOrDefault(x => x.Id == id);
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
}
