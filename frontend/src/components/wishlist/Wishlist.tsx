import React, { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { WishList, getWIshListForUser } from "../../clients/apiClient";
import { LoginContext } from "../login/LoginManager";
import "./Wishlist.scss";
import { WishListCard } from "./WishListCard";

export const Wishlist: React.FunctionComponent = () => {
  const [wishLists, setWishLists] = useState<WishList[]>();
  const loginContext = useContext(LoginContext);

  const removeWishListById = (id: number): void => {
    const newWishLists = wishLists?.filter(
      (Wishlist) => Wishlist.wishListId !== id
    );
    setWishLists(newWishLists);
  };

  useEffect(() => {
    getWIshListForUser(
      loginContext.userId,
      loginContext.username,
      loginContext.password
    ).then(setWishLists);
  }, [loginContext.userId]);

  if (wishLists === undefined) {
    return <p> Loading... </p>;
  }

  return (
    <div className="wishList-container">
      <h1>WISH LIST</h1>
      <div className="wishList">
        {wishLists.map((wishList) => {
          return (
            <WishListCard
              wishList={wishList}
              key={wishList.wishListId}
              remove={() => removeWishListById(wishList.wishListId)}
            />
          );
        })}
      </div>
    </div>
  );
};
