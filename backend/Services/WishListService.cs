using System;
using System.Collections.Generic;
using Sparsh.Models.Database;
using Sparsh.Repositories;

namespace Sparsh.Services
{
    public interface IWishListService
    {
        IEnumerable<WishList> GetWIshListForUser(int userId);
        bool IsExistingProduct(int userId, int productId);
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

        public bool IsExistingProduct(int userId, int productId)
        {
                var userWishList = _wishLists.GetWIshListForUser(userId);
                foreach(var item in userWishList)
                {
                    if(item.Item.ProductId == productId)
                    {
                        return true;
                    }
                }
                return false;
        }

        public WishList AddToWishList(WishListRequest request)
        {
            if(IsExistingProduct(request.UserId, request.ProductId))
            {
                throw new DuplicateWaitObjectException("Product already exists");
            }
            return _wishLists.AddToWishList(request);
        }

        public WishList DeleteFromWishList(int wishListId)
        {
            return _wishLists.DeleteFromWishList(wishListId);
        }
    }
}