import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import { Button } from '@material-ui/core';
import { NavLink } from 'react-router-dom';

const Header = () => {

    return (
        <div className='header'>
            <AppBar className='header__container' position="static">
                <NavLink to='/movies' isActive={(match, location) => { return location.pathname == "/" || location.pathname == "/movies" }} activeClassName={"active"}>
                    <Button className='header__button'>
                        Movies
                    </Button>
                </NavLink>
                <NavLink to='/tv-shows' activeClassName={"active"}>
                    <Button className='header__button'>
                        Tv Shows
                    </Button>
                </NavLink>
                <NavLink to='/ratings-list' activeClassName={"active"}>
                    <Button className='header__button'>
                        Rating list
                    </Button>
                </NavLink>
            </AppBar>
        </div>
    );
}

export default Header;