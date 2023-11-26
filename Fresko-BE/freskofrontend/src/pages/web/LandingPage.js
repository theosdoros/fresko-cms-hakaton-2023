import axios from 'axios';
import {route} from "./../../vars.js";
import {useEffect, useState} from 'react';

import { Link } from 'react-router-dom';

import WebHeader from '../../components/web/WebHeader.js'

import Logo from '../../images/LandingPageLogo.svg';

import Card1 from '../../images/LandingPageCard1.svg';
import Card2 from '../../images/LandingPageCard2.svg';
import Card3 from '../../images/LandingPageCard3.svg';
import Card4 from '../../images/LandingPageCard4.svg';

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
            <div className='homepage-hero-features-container'>

                <div className='homepage-hero-title-container'>
                    <p>Сва твоја креативност на једном месту</p>
                </div>
                <div className='homepage-hero-cards-container'>
                    <div className='homepage-hero-card-1'>
                        <p>Креирај</p>
                        <img src={ Card1 } />
                    </div>
                    <div className='homepage-hero-card-2'>
                        <p>Сачувај</p>
                        <img src={ Card2 } />
                    </div>
                    <div className='homepage-hero-card-3'>
                        <p>Подели</p>
                        <img src={ Card3 } />
                    </div>
                    <div className='homepage-hero-card-4'>
                        <p>Упознај</p>
                        <img src={ Card4 } />
                    </div>
                </div>
                <div className='homepage-hero-features-bottom'></div>
            </div>
            <div className='homepage-hero-footer-container'>
                <div className='homepage-hero-inspirational-container'>
                    <p className='homepage-hero-inspirational-head'>Ћирилица или Latinica?</p>
                    <p className='homepage-hero-inspirational-sec'>Nije bitno<br/>Имате подршку на ћирилици и латиници</p>
                </div>
                <div className='homepage-hero-footer'>
                    <img src={ Logo } />
                    <p className='Moto'>Откри своју машту</p>
                    <p className='Copyright'>Фреско © 2023. Лос Пољос Херманос д.о.о</p>
                </div>
            </div>
        </>
    );
}