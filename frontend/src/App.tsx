import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Home } from "./components/homepage/Home";
import { Navbar } from "./components/navbar/Navbar";
import { LoginManager } from "./components/login/LoginManager";
import { Footer } from "./components/footer/Footer";
import { Login } from "./components/login/Login";
import { Wishlist } from "./components/wishlist/Wishlist";
import { About } from "./components/about/About";
import { FacialCare } from "./components/facialCare/FacialCare";
import { HairCare } from "./components/hairCare/HairCare";
import { BodyCare } from "./components/bodyCare/BodyCare";
import { Combo } from "./components/combo/Combo";
import { Cart } from "./components/cart/Cart";
import { Orders } from "./components/orders/Orders";
import { OrderTracking } from "./components/orderTracking/OrderTracking";
import { PendingOrders } from "./components/pendingOrders/PendingOrders";
import { ProductById } from "./components/allProducts/ProductById";
import { Contact } from "./components/contact/Contact";
import { WarningPage } from "./components/warningPage/WarningPage";

const Routes: React.FunctionComponent = () => {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/about">
        <About />
      </Route>
      <Route exact path="/contact">
        <Contact />
      </Route>
      <Route exact path="/products/:productId">
        <ProductById />
      </Route>
      <Route exact path="/products/type/facial">
        <FacialCare />
      </Route>
      <Route exact path="/products/type/hair">
        <HairCare />
      </Route>
      <Route exact path="/products/type/body">
        <BodyCare />
      </Route>
      <Route exact path="/products/type/combos">
        <Combo />
      </Route>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/warning">
        <WarningPage />
      </Route>
      <Route exact path="/wishList">
        <Wishlist />
      </Route>
      <Route exact path="user/cart">
        <Cart />
      </Route>
      <Route exact path="user/orders">
        <Orders />
      </Route>
      <Route exact path="/user/orders/track">
        <OrderTracking />
      </Route>
      <Route exact path="/admin/orders/pending">
        <PendingOrders />
      </Route>
      <Route exact path="/admin/orders/track">
        <OrderTracking />
      </Route>
    </Switch>
  );
};

const App: React.FunctionComponent = () => {
  return (
    <Router>
      <LoginManager>
        <Navbar />
        <main className="page-content">
          <Routes />
        </main>
        <Footer />
      </LoginManager>
    </Router>
  );
};

export default App;
