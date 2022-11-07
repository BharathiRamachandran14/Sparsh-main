const backendUrl = process.env["REACT_APP_BACKEND_DOMAIN"];

export interface User {
  id: number;
  name: string;
  email: string;
  userName: string;
}

export const checkLogInDetails = async (
  username: string,
  password: string
): Promise<boolean> => {
  const response = await fetch(`${backendUrl}/login`, {
    headers: {
      Authorization: `Basic ${btoa(`${username}:${password}`)}`,
    },
  });
  return response.ok;
};
