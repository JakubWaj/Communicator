import React from 'react';
import {User} from "./Main.tsx";

interface Props {
    users: User[];
    setUserId: (userId: string) => void;
    setIsUserId: (isUserId: boolean) => void;
}


const AllUserList = ({users,setUserId,setIsUserId}:Props) => {
    const handleSetUser = (userId:string) => {
        console.log(userId);
        setUserId(userId);
        setIsUserId(true);
    };

    return (
        <div style={{width:"100%"}}>
            <ul className="user-list">
                {users.map((user) => {
                    return (
                        <li onClick={() => handleSetUser(user.id)} className="user-item" key={user.id}>
                            <h1>{user.username}</h1>
                        </li>
                    );
                })}
            </ul>
        </div>
    );
};

export default AllUserList;