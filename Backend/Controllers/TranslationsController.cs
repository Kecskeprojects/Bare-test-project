using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TranslationsController : ControllerBase
{
    private readonly DatabaseContext _context;

    public TranslationsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetTranslation")]
    public async Task<IActionResult> Get(string? originalString, string? translationLanguage)
    {
        if (translationLanguage == null || originalString == null || _context.Translations == null)
        {
            return new JsonResult(new Response(null, "Translation attempt failed!"));
        }

        translationLanguage = char.ToUpper(translationLanguage[0]) + translationLanguage[1..];

        Translation? translations = await _context.Translations.FirstOrDefaultAsync(n => n.English.ToLower() == originalString);

        string? result = "";

        if (translations != null)
        {
            System.Reflection.PropertyInfo? prop = typeof(Translation).GetProperty(translationLanguage);
            if (prop != null)
            {
                object? value = prop.GetValue(translations);
                if (value != null)
                {
                    result = (string) value;
                }
            }
        }

        return string.IsNullOrEmpty(result)
            ? new JsonResult(new Response(null, "Translation not found in database!"))
            : (IActionResult) new JsonResult(new Response(result, null));
    }
}
