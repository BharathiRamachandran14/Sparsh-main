import React, { useContext, useState } from "react";
import { Link } from "react-router-dom";
import { LoginContext } from "../login/LoginManager";
import "./Navbar.scss";
import Hamburger from "hamburger-react";
import { RiUserFill } from "react-icons/ri";

export const Navbar: React.FunctionComponent = () => {
  const loginContext = useContext(LoginContext);
  const [isExpanded, setIsExpanded] = useState(false);

  return (
    <nav className="navbar" role="navigation" aria-label="main navigation">
      <div className="mobile-menu">
        <Hamburger toggled={isExpanded} toggle={setIsExpanded} />
      </div>
      <Link to="/">
        <img className="navbar__logo" src="/logo.jpg" alt="Sparsh logo" />
      </Link>
      <ul className={`menu-items ${isExpanded ? "expanded" : ""}`}>
        <Link to="/" onClick={() => setIsExpanded(false)}>
          Home
        </Link>
        <Link to="/products/face" onClick={() => setIsExpanded(false)}>
          Facial Care
        </Link>
        <Link to="/products/hair" onClick={() => setIsExpanded(false)}>
          Hair Care
        </Link>
        <Link to="/products/body" onClick={() => setIsExpanded(false)}>
          Body Care
        </Link>
        <Link to="/products/combos" onClick={() => setIsExpanded(false)}>
          Combos & Gifting
        </Link>
        <Link to="/products/face" onClick={() => setIsExpanded(false)}>
          Facial Care
        </Link>

        <div className="user-admin-links">
          {!loginContext.isLoggedIn ? (
            <Link
              to="/login"
              className="icon"
              onClick={() => setIsExpanded(false)}
            >
              <RiUserFill size={25} />
            </Link>
          ) : (
            <div className="logged-in-links">
              <button
                onClick={() => {
                  setIsExpanded(false);
                  loginContext.logOut();
                }}
              >
                Log Out
              </button>
            </div>
          )}
        </div>
      </ul>
    </nav>
  );
};
