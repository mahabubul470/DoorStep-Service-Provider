import React, { useState, useEffect } from "react";
import { Typography } from "@material-ui/core";
import { Box } from "@material-ui/core";
import { Button, CssBaseline, AppBar, Toolbar } from "@material-ui/core";
import StickyFooter from "./footer";
import Nav from "./Nav";

export default function Landing_page() {
  useEffect(() => {
    document.title = "Welcome";
  }, []);
  return (
    <React.Fragment>
      <CssBaseline />
      <AppBar position="relative">
        <Toolbar>
          <Typography variant="h6" color="inherit" noWrap>
            xyz
          </Typography>
        </Toolbar>
      </AppBar>
    </React.Fragment>
  );
}
