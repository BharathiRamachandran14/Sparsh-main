import { getRoles } from "@testing-library/react";
import React, { createContext, useState } from "react";
import { logIn, UserResponse, Role } from "../../clients/apiClient";

type LoginContextType = {
  isLoggedIn: boolean;
  isAdmin: boolean;
  username: string;
  password: string;
  userId: number;
  logIn: (username: string, password: string) => Promise<boolean>;
  logOut: () => void;
};

export const LoginContext = createContext<LoginContextType>({
  isLoggedIn: false,
  isAdmin: false,
  username: "",
  password: "",
  userId: 0,
  logIn: async () => false,
  logOut: () => {
    console.log();
  },
});

export const LoginManager: React.FunctionComponent = ({ children }) => {
  const [loggedIn, setLoggedIn] = useState(false);
  const [contextusername, setUsername] = useState("");
  const [contextPassword, setPassword] = useState("");
  const [contextUserId, setUserId] = useState(0);
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
      setUserId(logInDetails.id);
      setLoggedIn(true);
      if (role === "admin") {
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
    setUserId(0);
    setAdmin(false);
  }

  const context = {
    isLoggedIn: loggedIn,
    isAdmin: Admin,
    username: contextusername,
    password: contextPassword,
    userId: contextUserId,
    logIn: tryLogIn,
    logOut: logOut,
  };

  return (
    <LoginContext.Provider value={context}>{children}</LoginContext.Provider>
  );
};
