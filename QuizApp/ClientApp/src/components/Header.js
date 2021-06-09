import React, {useState} from 'react';
import { HeaderLogin } from './HeaderLogin';
import { HeaderProfile } from './HeaderProfile';




function Header (){
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    

    const handleLoggedInStatus = () => {
            setIsLoggedIn(!false);
    }

    return !isLoggedIn ? (
        <div>
        <HeaderLogin/>
        </div>
    ) : (
        <div>
        <HeaderProfile/>
        </div>
    );
}




export default Header;