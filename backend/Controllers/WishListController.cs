using System;
using Microsoft.AspNetCore.Mvc;
using Sparsh.Helpers;
using Sparsh.Models.Database;
using Sparsh.Models.Response;
using Sparsh.Services;


namespace Sparsh.Controllers
{
    [ApiController]
    [Route("/wishList")]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishLists;
        private readonly IAuthService _authService;

        public WishListController
        (
            IWishListService wishLists,
            IAuthService authService

        )
        {
            _wishLists = wishLists;
            _authService = authService;
        }

        [HttpGet("{userId}")]
        public ActionResult<ListResponse<WishList>> GetWishListForUser([FromHeader] string authorization, [FromRoute]int userId)
        {
             if(authorization is null)
            {
                return new UnauthorizedResult();
            }
            try
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

                var check = _authService.IsValidLoginInfo(username, password);
                if (!check)
                {
                    return Unauthorized();
                }
            var wishLists = _wishLists.GetWIshListForUser(userId);
            return new ListResponse<WishList>(wishLists);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<WishListResponse> AddToWishList([FromHeader] string authorization,
                                          [FromBody] WishListRequest newWishListRequest)
        {
            if(authorization is null)
            {
                return new UnauthorizedResult();
            }
            try
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

                var check = _authService.IsValidLoginInfo(username, password);
                if (!check)
                {
                    return Unauthorized();
                }
                WishList addedWishList = _wishLists.AddToWishList(newWishListRequest);
                return new WishListResponse(addedWishList);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }                           

        [HttpDelete("delete/{wishListId}")]
        public ActionResult DeleteFromWishList([FromRoute]int wishListId, [FromHeader] string authorization)
        {
            if(authorization is null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

                var check = _authService.IsValidLoginInfo(username, password);

                if (!check)
                {
                    return Unauthorized();
                }
                var deletedWishList = _wishLists.DeleteFromWishList(wishListId);
                return Ok();
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

        }  
    }
}