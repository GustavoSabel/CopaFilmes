﻿using CopaMundoFilmes.Api.Services;
using CopaMundoFilmes.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaMundoFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly FilmeService _filmeService;

        public FilmesController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public Task<List<Filme>> Get() => _filmeService.ObterFilmes();
    }
}
