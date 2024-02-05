import {Message, User} from "./Main.tsx";
import React, {useEffect, useRef, useState} from "react";

interface Props {
    messages: Message[];
    groupName: string;
    groupUsers: User[];
    handleMessagesChange: (content: string) => void;
}

const Messages = ({messages,handleMessagesChange,groupUsers,groupName}:Props) => {
    console.log("XD");
    console.log(groupUsers);
    console.log("XD");
    const [message, setMessage] = useState<Message | null>(null);
    const [content, setContent] = useState<string>("");

    const listRef = useRef<HTMLUListElement>(null);

    useEffect(() => {
        if (listRef.current) {
            listRef.current.scrollTop = listRef.current.scrollHeight - listRef.current.clientHeight;
        }
    }, []);

    useEffect(() => {
        if (listRef.current) {
            listRef.current.scrollTop = listRef.current.scrollHeight - listRef.current.clientHeight;
        }
    }, [messages]);
    
    const handleKeyPress = (e:any) => {
        if (e.key === 'Enter') {
            if (content.trim() === "") {
                return;
            }
            handleMessagesChange(content);
            setContent("");
        }
    };
    let i =0 ;
    //function which find username by id
    const findUsername = (id:string) => {
        let username = "";
        groupUsers.forEach((user) => {
            if (user.id === id) {
                username = user.username;
            }
        }   
        );
        return username;
    };

    function format(date:string) {
        const parts = date.split('T');
        const datePart = parts[0];
        const timePart = parts[1].split('.')[0];

        const [year, month, day] = datePart.split('-');
        const [hours, minutes, seconds] = timePart.split(':');

        return `${year}-${month}-${day} ${hours}:${minutes}`;
    }
    
    const [toggleGroup, setToggleGroup] = useState(false);
    
    
    
    return (
        <div className="message-div">
            {messages.length === 0 ? <h1>Brak wiadomości</h1>
            : <>
                <h1 style={{textAlign:"center",width:"50%"}}>{groupName}</h1>
            <ul className="nav-list" ref={listRef}>
                {messages.map((message) => {
                    return<div className="message-box">
                        <li className="username" key={i}> Wysłane przez {findUsername(message.userId)} o {format(message.createdAt.toString())}</li>
                        <li className="message" key={message.id}>{message.content}</li>
                    </div>
                }
                )}
            </ul></>
            }
            <textarea
                className="message-field"
                onKeyDown={handleKeyPress}
                value={content}
                onChange={(e)=>setContent(e.target.value)}
                placeholder="Wyślij wiadomość">
            </textarea>
        </div>
    );
};

export default Messages;