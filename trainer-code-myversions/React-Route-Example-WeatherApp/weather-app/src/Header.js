import React, { useEffect, useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import  { Link }  from 'react-router-dom';

const Header = () => {
    return(
        <header>
            <nav>
                <ul>
                    <li><Link to = "/">Home</Link></li>
                    <li><Link to = "/weather">Weather</Link></li>
                    <li>Home</li>
                </ul>
            </nav>
        </header>
    )
}

export default Header;