import axios from 'axios';
import {route} from "./../../vars.js";
import {useEffect, useState} from 'react';

import { Link } from 'react-router-dom';

import "..//..//AdminPanelStyle.css";

import Logo from '../../images/LandingPageLogo.svg';

export default function AdminPanel() {

    useEffect(() => {

    }, [])

    const [users, setUsers] = useState( [] );

    const getUsers = async () => { await axios
      .get(route + "/Admin/Users/")
      .then((res) => {
        setUsers( res.data );
        console.log(res.data)
      })
      .catch((err) => console.log(err));
    };
    
    
    

    return(
        <>
            <div className='adminpanel-hero-container'>
                <div className='adminpanel-sidepanel-container'>
                    <div className='adminpanel-sidepanel-admin-container'>
                        <p> Администратор </p>
                    </div>
                    <div className='adminpanel-sidepanel-function-container'>
                        <ul>
                            <li className='adminpanel-sidepanel-dashboard-container' >
                                <Link to="/fresko/admin-panel"><i class="fa-solid fa-hashtag"></i>Командна табла</Link>
                            </li>
                            <li>
                                <Link to="#"><i className="fa-solid fa-users"></i>Корисници</Link>
                            </li>
                            {/* <li>
                                <Link to="/fresko/admin-panel"><i class="fa-solid fa-photo-film"></i>Медија</Link>
                            </li> */}
                        </ul>
                    </div>
                    <div className='adminpanel-sidepanel-logo-container'>
                        <img src={ Logo } height="150px"/>
                        <p>Фреско © 2023. Лос Пољос Херманос д.о.о</p>
                    </div>
                </div>
                <div className='adminpanel-main-container'>
                    <div className='adminpanel-main-toppanel-container'>
                        <input placeholder='Пронађите корисника овде...'/>
                    </div>
                    <div className='adminpanel-main-content-container'>
                            <div className='adminpanel-main-content-card'>
                                <p>
                                    fsfsdfsdgdsghdfshdghdshfgdsfdsf
                                </p>
                                <Link to="/Admin/DeleteUser"><i className="fa-solid fa-user-plus"></i>Одобри корисника</Link>
                                <Link to="/Admin/AddApproveUser"><i className="fa-solid fa-user-minus"></i>Избриши корисника</Link>
                            </div>
                    </div>
                </div>
            </div>
        </>
    );
}