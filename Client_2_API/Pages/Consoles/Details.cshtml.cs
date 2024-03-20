﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Client_2_API.API;

namespace Client_2_API.Pages.Consoles
{
    public class DetailsModel : PageModel
    {
        //private readonly Projet2_API.Data.Projet2_APIContext _context;
        private readonly IConsoleClient _consoleClient;

        public DetailsModel(IConsoleClient context)
        {
            _consoleClient = context;
        }

        public GameConsole GameConsole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var gameconsole = await _context.GameConsole.FirstOrDefaultAsync(m => m.Id == id);
            GameConsole = await _consoleClient.GameConsolesGETAsync(id.Value);

            if (GameConsole == null)
            {
                return NotFound();
            }
            /*else
            {
                GameConsole = gameconsole;
            }*/
            return Page();
        }
    }
}
