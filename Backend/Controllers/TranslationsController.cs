﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using System.Net;

namespace Backend.Controllers
{
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

            var translations = await _context.Translations.FirstOrDefaultAsync(n => n.English.ToLower() == originalString);

            string? result = "";

            if(translations != null)
            {
                var prop = typeof(Translation).GetProperty(translationLanguage);
                if (prop != null)
                {
                    var value = prop.GetValue(translations);
                    if (value != null)
                    {
                        result = (string)value;
                    }
                }
            }

            if (string.IsNullOrEmpty(result))
            {
                return new JsonResult(new Response(null, "Translation not found in database!"));
            }

            return new JsonResult(new Response(result, null));
        }
    }
}
