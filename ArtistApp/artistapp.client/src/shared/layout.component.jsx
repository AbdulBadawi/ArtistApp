/* eslint-disable react/prop-types */
import { NavLink } from "react-router-dom";
import { GenerateClassType } from "../utils/utilServices";

const ArtistMenuLayout = (props) => {
  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarTogglerDemo03"
            aria-controls="navbarTogglerDemo03"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <NavLink to={"/artist"} className="navbar-brand">
            <img
              src="https://static.vecteezy.com/system/resources/previews/016/891/616/non_2x/little-girl-singing-and-playing-guitar-music-performance-by-kid-cartoon-illustration-free-vector.jpg"
              alt="Logo"
              style={{ width: "40px" }}
              className="rounded-pill"
            />
          </NavLink>

          <div className="collapse navbar-collapse" id="navbarTogglerDemo03">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <NavLink
                  to={"/artist"}
                  className={({ isActive }) => GenerateClassType(isActive)}
                >
                  Artist
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink
                  to={"/album"}
                  className={({ isActive }) => GenerateClassType(isActive)}
                >
                  Album
                </NavLink>
              </li>
              <li className="nav-item">
                <NavLink
                  to={"/track"}
                  className={({ isActive }) => GenerateClassType(isActive)}
                >
                  Track
                </NavLink>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <main className="py-2 px-4 flex-1 container mt-3">{props.children}</main>
    </div>
  );
};

export default ArtistMenuLayout;
