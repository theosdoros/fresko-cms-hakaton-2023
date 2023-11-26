import axios from 'axios';
import {route} from "./../../vars.js";
import {useEffect, useState} from 'react';

import { Link } from 'react-router-dom';

import WebHeader from '../../components/web/WebHeader.js'

export default function LandingPage() {

    useEffect(() => {

    }, [])

    return(
        <>
            <div className='homepage-hero-container'>
                <div className='homepage-landingpage-container'>
                    <WebHeader />
                    <div className='homepage-hero-content-container'>
                        <div className='homepage-landingpage-leftside-content-container'>
                            <div className='leftside-main-content-container'>
                                <h2>Пронађи, креирај, дели</h2>
                                <h3>своју креативност са другима</h3>
                                <h4>Пронађи друге особе као ти што воле да <br/>
                                    креирају, дизајнирају, објављају своја <br/>
                                    дела путем платформе која нема границе.</h4>
                                <h5>Немаш налог?</h5>
                                <Link to="/fresko/register">Региструј се</Link>
                            </div>
                        </div>
                        <div className='homepage-landingpage-rightside-content-container'>
                            <div className='rightside-main-content-container'>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}