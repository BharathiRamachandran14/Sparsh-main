const backendUrl = process.env["REACT_APP_BACKEND_DOMAIN"];

export interface ListResponse<T> {
  items: T[];
}

export type Role = "user" | "admin";

export type ProductType = "facial" | "hair" | "body";

export interface UserResponse {
  id: number;
  name: string;
  username: string;
  role: number;
  email: string;
  phoneNumber: string;
  address: string;
}

export interface User {
  id: number;
  name: string;
  username: string;
  role: Role;
  email: string;
  phoneNumber: string;
  address: string;
}

export interface Product {
  productId: number;
  productName: string;
  pricePerProduct: number;
  productImageUrl: string;
  productDescription: string;
  productType: ProductType;
}

export interface ProductResponse {
  productId: number;
  productName: string;
  pricePerProduct: number;
  productImageUrl: string;
  productDescription: string;
  productType: number;
}

export interface WishListResponse {
  wishListId: number;
  item: ProductResponse;
  user: UserResponse;
}

export interface WishList {
  wishListId: number;
  item: Product;
  user: User;
}

export interface WishListRequest {
  productId: number;
  userId: number;
}

interface TypeMapping {
  [key: number]: ProductType;
}

const typeMapping: TypeMapping = {
  0: "facial",
  1: "hair",
  2: "body",
};

interface RoleMapping {
  [key: number]: Role;
}
const roleMapping: RoleMapping = {
  0: "user",
  1: "admin",
};

export const logIn = async (
  username: string,
  password: string
): Promise<User> => {
  const response = await fetch(`${backendUrl}/login`, {
    headers: {
      Authorization: `Basic ${btoa(`${username}:${password}`)}`,
    },
  });
  const userResponse: UserResponse = await response.json();
  const user: User = {
    ...userResponse,
    role: roleMapping[userResponse.role],
  };
  return user;
};

export const getAllProducts = async (): Promise<Product[]> => {
  const productList: Product[] = [];
  const response = await fetch(`${backendUrl}/products`);
  const productsListResponse: ListResponse<ProductResponse> =
    await response.json();
  for (let i = 0; i < productsListResponse.items.length; i++) {
    const productType = productsListResponse.items[i].productType;
    productList[i] = {
      ...productsListResponse.items[i],
      productType: typeMapping[productType],
    };
  }
  return productList;
};

export const getProductById = async (productId: string): Promise<Product> => {
  const response = await fetch(`${backendUrl}/products/${productId}`);
  const productResponse: ProductResponse = await response.json();
  const product: Product = {
    ...productResponse,
    productType: typeMapping[productResponse.productType],
  };
  return product;
};

export const getProductsByType = async (
  productType: ProductType
): Promise<Product[]> => {
  const reverseTypeMapping: { [key in ProductType]: number } = {
    facial: 0,
    hair: 1,
    body: 2,
  };
  const typeCode = reverseTypeMapping[productType];
  const productList: Product[] = [];
  const response = await fetch(`${backendUrl}/products/type/${typeCode}`);
  const productsListResponse: ListResponse<ProductResponse> =
    await response.json();
  for (let i = 0; i < productsListResponse.items.length; i++) {
    const productType = productsListResponse.items[i].productType;
    productList[i] = {
      ...productsListResponse.items[i],
      productType: typeMapping[productType],
    };
  }
  return productList;
};

export const addToWishList = async (
  wishListRequest: WishListRequest,
  username: string,
  password: string
) => {
  const response = await fetch(`${backendUrl}/wishList`, {
    method: "POST",
    body: JSON.stringify(wishListRequest),
    headers: {
      "Content-Type": "application/json",
      Authorization: `Basic ${btoa(`${username}:${password}`)}`,
    },
  });
  return response.ok;
};

export const deleteFromWishList = async (
  wishListId: number,
  username: string,
  password: string
) => {
  const response = await fetch(`${backendUrl}/wishList/delete/${wishListId}`, {
    method: "DELETE",
    headers: {
      Authorization: `Basic ${btoa(`${username}:${password}`)}`,
    },
  });
  return response.ok;
};

export const getWIshListForUser = async (
  userId: number
): Promise<WishList[]> => {
  const wishList: WishList[] = [];
  const response = await fetch(`${backendUrl}/wishlist/${userId}`);
  const userWishListResponse: ListResponse<WishListResponse> =
    await response.json();
  if (userWishListResponse.items !== undefined) {
    for (let i = 0; i < userWishListResponse.items.length; i++) {
      const itemResponse = userWishListResponse.items[i].item;
      const userResponse = userWishListResponse.items[i].user;
      const productType = userWishListResponse.items[i].item.productType;
      const roleOfUser = userWishListResponse.items[i].user.role;
      wishList[i] = {
        ...userWishListResponse.items[i],
        item: { ...itemResponse, productType: typeMapping[productType] },
        user: { ...userResponse, role: roleMapping[roleOfUser] },
      };
    }
  }
  return wishList;
};
