﻿using libreria_MCLG.Data.Services;
using libreria_MCLG.Data.ViewModels;
using libreria_MCLG.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace libreria_MCLG.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PublishersController : ControllerBase
	{
		private PublisherService _publisherService;
		public PublishersController(PublisherService publisherService)
		{
			_publisherService = publisherService;
		}

		[HttpPost("add-publisher")]
		public IActionResult AddPublisher([FromBody] PublisherVM publisher)
		{
			try
			{
				var newPublisher = _publisherService.AddPublisher(publisher);
				return Created(nameof(AddPublisher), newPublisher);
			}
			catch(PublisherNameExceptions ex)
			{
				return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpGet("get-publisher-by-id-/{id}")]
		public IActionResult GetPublisherById(int id)
		{
			var _response = _publisherService.GetPublisherByID(id);
			if (_response != null)
			{
				return Ok(_response);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("get-publisher-books-with-authors-/{id}")]
		public IActionResult GetPublisherData(int id)
		{
			var _response = _publisherService.GetPublisherData(id);
			return Ok(_response);
		}

		[HttpDelete("delete-publisher-by-id/{id}")]
		public IActionResult DeletePublisherById(int id)
		{
			try
			{
				_publisherService.DeletePublisherById(id);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
