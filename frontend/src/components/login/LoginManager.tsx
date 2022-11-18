import { getRoles } from "@testing-library/react";
import React, { createContext, useState } from "react";
import { logIn, UserResponse, Role } from "../../clients/apiClient";

type LoginContextType = {
  isLoggedIn: boolean;
  isAdmin: boolean;
  username: string;
  password: string;
  logIn: (username: string, password: string) => Promise<boolean>;
  logOut: () => void;
};

export const LoginContext = createContext<LoginContextType>({
  isLoggedIn: false,
  isAdmin: false,
  username: "",
  password: "",
  logIn: async () => false,
  logOut: () => {
    console.log();
  },
});

export const LoginManager: React.FunctionComponent = ({ children }) => {
  const [loggedIn, setLoggedIn] = useState(false);
  const [contextusername, setUsername] = useState("");
  const [contextPassword, setPassword] = useState("");
  const [Admin, setAdmin] = useState(false);

  async function tryLogIn(
    username: string,
    password: string
  ): Promise<boolean> {
    const logInDetails = await logIn(username, password);
    const role = logInDetails.role;
    if (logInDetails) {
      setUsername(username);
      setPassword(password);
      setLoggedIn(true);
      if (logInDetails.role) {
        setAdmin(true);
      } else {
        setAdmin(false);
      }
      return true;
    } else {
      return false;
    }
  }

  function logOut() {
    setLoggedIn(false);
    setUsername("");
    setPassword("");
    setAdmin(false);
  }

  const context = {
    isLoggedIn: loggedIn,
    isAdmin: Admin,
    username: contextusername,
    password: contextPassword,
    logIn: tryLogIn,
    logOut: logOut,
  };

  return (
    <LoginContext.Provider value={context}>{children}</LoginContext.Provider>
  );
};
