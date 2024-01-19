// NavMenu.js

import React, { useState, useEffect } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Container } from 'reactstrap';
import { Link } from 'react-router-dom';
import { useAuth } from '../AuthContext';
import './NavMenu.css';

function NavMenu() {
    const { user, logout } = useAuth();
    const [collapsed, setCollapsed] = useState(true);
    const [isUserLoggedIn, setIsUserLoggedIn] = useState(false);

    useEffect(() => {
        const username = localStorage.getItem('username');
        setIsUserLoggedIn(username !== null);
    }, []);

    const toggleNavbar = () => {
        setCollapsed(!collapsed);
    };

    const handleLogout = () => {
        logout();
        localStorage.removeItem('username'); // Remove the username from local storage
        window.location.reload();
    };

    return (
        <header>
            <Navbar color="light" light expand="md" className="border-bottom box-shadow mb-3">
                <Container className="nav-menu-container">
                    {/* Left-aligned Weather Maroc brand */}
                    <NavbarBrand tag={Link} to="/">Weather Maroc</NavbarBrand>

                    {/* Navbar toggle button */}
                    <NavbarToggler onClick={toggleNavbar} />

                    {/* Right-aligned nav items */}
                    <Collapse isOpen={!collapsed} navbar>
                        <ul className="navbar-nav">
                            <NavItem>
                                <NavLink tag={Link} to="/">Home</NavLink>
                            </NavItem>
                            {isUserLoggedIn ? (
                                <>
                                    <NavItem>
                                        <span className="navbar-text">{localStorage.getItem('username')}</span>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} to="/" onClick={handleLogout}>Logout</NavLink>
                                    </NavItem>
                                </>
                            ) : (
                                <>
                                    <NavItem>
                                        <NavLink tag={Link} to="/login">Login</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink tag={Link} to="/signup">Signup</NavLink>
                                    </NavItem>
                                </>
                            )}
                        </ul>
                    </Collapse>
                </Container>
            </Navbar>
        </header>
    );
}

export default NavMenu;
