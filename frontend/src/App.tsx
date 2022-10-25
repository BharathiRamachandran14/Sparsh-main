import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Home } from "./components/homepage/Home";
import { Navbar } from "./components/navbar/Navbar";
import { LoginManager } from "./components/login/LoginManager";
import { Footer } from "./components/footer/Footer";
import { BrowseSightings } from "./components/browse-sightings-page/BrowseSightings";
import { CreateUser } from "./components/create-user-page/CreateUser";
import { PendingSightings } from "./components/pending-sightings-page/PendingSightings";
import { Videos } from "./components/videos-page/Videos";
import { Whaleopedia } from "./components/whaleopedia-page/Whaleopedia";
import { Login } from "./components/login/Login";

const Routes: React.FunctionComponent = () => {
  return (
    <Switch>
      <Route exact path="/">
        <Home />
      </Route>
      <Route exact path="/sightings">
        <BrowseSightings />
      </Route>
      <Route exact path="/whaleopedia">
        <Whaleopedia />
      </Route>
      <Route exact path="/videos">
        <Videos />
      </Route>
      <Route exact path="/login">
        <Login />
      </Route>
      <Route exact path="/sightings/pending">
        <PendingSightings />
      </Route>
      <Route exact path="/users/create">
        <CreateUser />
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
