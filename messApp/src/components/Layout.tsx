import {Outlet, useLocation, useNavigate} from "react-router-dom"
import {useEffect} from "react";

const Layout = () => {
    return (
        <main className="App">
            <Outlet />
            </main>
    )
}

export default Layout