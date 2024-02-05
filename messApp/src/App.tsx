import './App.css'
import Register from "./components/auth/Register.tsx";
import Login from "./components/auth/Login.tsx";
import {Route, Routes} from "react-router-dom";
import Layout from "./components/Layout.tsx";
import Home from "./components/Home.tsx";
import RequireAuth from "./components/RequireAuth.tsx";
import Main from "./components/Main.tsx";

function App() {
  return (
      <Routes>
        <Route path="/" element={<Layout/>}>
            <Route path="/" element={<Home/>}></Route>
            <Route path="/register" element={<Register/>}></Route>
            <Route path="/login" element={<Login/>}></Route>
            <Route path="/main" element={<Main/>}></Route>
        </Route>
      </Routes>
  )
}

export default App
