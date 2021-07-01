using Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageApiDDD.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {
        private readonly ImageService ImageService;

        public ImageController(ImageService _ImageService)
        {
            ImageService = _ImageService;
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<Image>> GetImage()
        {
            return await ImageService.GetAllImage();
        }

        //Get/{id}
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Image>> GetImage(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                return await ImageService.GetByIdImage(id);
            }
        }

        //Post
        [HttpPost]
        public async Task<ActionResult<Image>> PostImage([FromBody] Image data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Check the data sent.");
            }
            else
            {
                try
                {
                    var datas = await ImageService.PostImage(data);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Put
        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult<Image>> PutImage(int id, [FromBody] Image Image)
        {
            if (id != Image.Id)
            {
                return BadRequest("The given id is not the same as the json id.");
            }
            else
            {
                try
                {
                    var datas = await ImageService.PutImage(Image);
                    return Ok(datas);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Delete
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult<Image>> DeleteImage(int? id)
        {
            if (id == null)
                return BadRequest("Please, provide an Id");
            else
            {
                try
                {
                    var data = await ImageService.DeleteImage(id);
                    return Ok(data);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }

        //Get/username{username}
        [Route("username/{username}")]
        [HttpGet]
        public async Task<ActionResult<Image>> GetImagebyUsername(string? username)
        {
            if (username == null)
                return BadRequest("Please, provide an Username");
            else
            {
                return await ImageService.GetByIdImage(username);
            }
        }


        //Get/feedback/{id}/{type}
        [Route("feedback/{id}/{type}")]
        [HttpPatch]
        public async Task<ActionResult<Image>> SendFeedback(int? id, string type)
        {
            try
            {
                Image image = await ImageService.GetByIdImage(id);

                switch (type)
                {
                    case "like":
                        image.Likes++;
                        break;
                    case "dislike":
                        image.Likes--;
                        break;
                }

                Image imageUpdated = await ImageService.PutImage(image);

                return Ok(imageUpdated);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}
