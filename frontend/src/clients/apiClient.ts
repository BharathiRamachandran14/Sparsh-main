const backendUrl = process.env["REACT_APP_BACKEND_DOMAIN"];

export interface ListResponse<T> {
  items: T[];
}

export type Role = "user" | "admin";

export type ProductType = "facial" | "hair" | "body";

export interface UserResponse {
  name: string;
  username: string;
  role: number;
  email: string;
  phoneNumber: string;
  address: string;
}

export interface User {
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

interface TypeMapping {
  [key: number]: ProductType;
}

const typeMapping: TypeMapping = {
  0: "facial",
  1: "hair",
  2: "body",
};

export const logIn = async (
  username: string,
  password: string
): Promise<User> => {
  interface RoleMapping {
    [key: number]: Role;
  }
  const roleMapping: RoleMapping = {
    0: "user",
    1: "admin",
  };
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
