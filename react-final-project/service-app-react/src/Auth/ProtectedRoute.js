import React from "react";
import { Route, Redirect } from "react-router-dom";
const isAuthenticated = () => {
  let id = sessionStorage.getItem("userid");
  if (id != null) return true;
  else return false;
};
export const ProtectedRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) => {
        if (isAuthenticated()) {
          return <Component {...props} />;
        } else {
          return (
            <Redirect
              to={{
                pathname: "/signin",
                state: {
                  from: props.location,
                },
              }}
            />
          );
        }
      }}
    />
  );
};
