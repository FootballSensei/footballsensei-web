﻿using FootballSensei.Models.DTOs;
using FootballSensei.Services.MatchService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballSensei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public readonly IMatchService _matchService;

        [HttpGet]
        public async Task<IActionResult> GetAllMatches()
        {
            var matches = await _matchService.GetAllMatches();
            return Ok(matches);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMatch(CreateMatchDTO matchDTO)
        {
            var matches = await _matchService.CreateMatch(matchDTO);
            return Ok(matches);
        }
    }
}
