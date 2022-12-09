using System.Collections.Generic;
using Sparsh.Models.Database;
using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface IWishListService
    {
        IEnumerable<WishList> GetWIshListForUser(int userId);
        WishList AddToWishList(WishListRequest request);
        WishList DeleteFromWishList(int wishListId);
    }

    public class WishListService: IWishListService
    {
        private readonly IWishListRepo _wishLists;
        
        public WishListService
        (
            IWishListRepo wishLists
        )
        {
            _wishLists = wishLists;
        }

         public IEnumerable<WishList> GetWIshListForUser(int userId)
         {
            return _wishLists.GetWIshListForUser(userId);
         }

         public WishList AddToWishList(WishListRequest request)
         {
            return _wishLists.AddToWishList(request);
         }

         public WishList DeleteFromWishList(int wishListId)
         {
            return _wishLists.DeleteFromWishList(wishListId);
         }
    }
}