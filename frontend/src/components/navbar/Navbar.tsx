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
        <Link to="/products/type/facial" onClick={() => setIsExpanded(false)}>
          Facial Care
        </Link>
        <Link to="/products/type/hair" onClick={() => setIsExpanded(false)}>
          Hair Care
        </Link>
        <Link to="/products/type/body" onClick={() => setIsExpanded(false)}>
          Body Care
        </Link>
        {/* <Link to="/products/combos" onClick={() => setIsExpanded(false)}>
          Combos & Gifting
        </Link> */}
        <div className="user-admin-links">
          {!loginContext.isLoggedIn ? (
            <Link
              to="/login"
              className="icon"
              onClick={() => setIsExpanded(false)}
            >
              <RiUserFill size={25} />
            </Link>
          ) : !loginContext.isAdmin ? (
            <div className="logged-in-links">
              <Link to="/wishList" onClick={() => setIsExpanded(false)}>
                Wish List
              </Link>
              {/* <Link to="/users/create" onClick={() => setIsExpanded(false)}>
                User +
              </Link> */}
              <Link to="/user/cart" onClick={() => setIsExpanded(false)}>
                Cart
              </Link>
              <Link to="/user/orders" onClick={() => setIsExpanded(false)}>
                Orders
              </Link>
              <div>
                <button
                  onClick={() => {
                    setIsExpanded(false);
                    loginContext.logOut();
                  }}
                >
                  Log Out
                </button>
              </div>
            </div>
          ) : (
            <div className="logged-in-links">
              <Link
                to="/admin/orders/pending"
                onClick={() => setIsExpanded(false)}
              >
                Pending Orders
              </Link>
              <div>
                <button
                  onClick={() => {
                    setIsExpanded(false);
                    loginContext.logOut();
                  }}
                >
                  Log Out
                </button>
              </div>
            </div>
          )}
        </div>
      </ul>
    </nav>
  );
};
