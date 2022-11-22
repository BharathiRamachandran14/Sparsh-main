import { Link } from "react-router-dom";
import "./Footer.scss";

export const Footer: React.FunctionComponent = () => (
  <footer>
    <Link to="/about">About</Link>
    <Link to="/contact">Contact us</Link>
  </footer>
);
