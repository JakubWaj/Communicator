import React from 'react';
import {Group} from "./Main.tsx";

interface Props {
    username: string;
    groups: Group[];
    handleGroupChange: (group: Group) => void;
}
const Groups = ({groups,handleGroupChange,username}:Props) => {
    return (
        <div className="group-div">
            <h1>{username} : Grupy</h1>
            <ul className="group-list">
                {groups.map((group) => {
                    console.log(group);
                    return <li className="group-item" onClick={()=>handleGroupChange(group)} key={group.id}><h1>{group.name}</h1></li>
                }
                )}
            </ul>
        </div>
    );
};

export default Groups;