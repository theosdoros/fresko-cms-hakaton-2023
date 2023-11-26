import axios from 'axios';
import {route} from "../../vars.js";
import {useEffect, useState} from 'react';

import { Link, Outlet } from 'react-router-dom';

import Logo from '../../images/LandingPageLogo.svg';

export default function WebHeader() {

    useEffect(() => {

    }, [])

    return(
        <>
            <div className='homepage-navigation-container'>
                <div className='navigation-image-container'>
                    <Link to="/"><img src={Logo} height="100px" /></Link>
                </div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/"> Почетна </Link>
                        </li>
                        <li>
                            <Link to="/fresko/about"> О нама </Link>
                        </li>
                        <li>
                            <Link to="/fresko/login" className='navigation-hero-login'> Пријави се </Link>
                        </li>
                    </ul>
                </nav>
            </div>
        </>
    );
}