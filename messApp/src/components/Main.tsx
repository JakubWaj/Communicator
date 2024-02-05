import React, {useEffect,useState} from 'react';
import {useAxios} from "../hooks/useAxios.ts";
import Groups from "./Groups.tsx";
import Messages from "./Messages.tsx";
import AllUserList from "./AllUserList.tsx";
export interface User {
    id: string;
    username: string;
    email: string;
}

export interface Message {
    id: string;
    content: string;
    userId: string;
    createdAt: Date;
}

export interface Group {
    id: string;
    name: string;
    users: any[];
    messages: Message[];
}

const Main = () => {
    
    const axios = useAxios();
    const [groups, setGroups] = useState<Group[]>([]);
    const [messages, setMessages] = useState<Message[]>([]);
    const [group, setGroup] = useState<Group>();
    const [groupUsers, setGroupUsers] = useState<User[]>([]);
    const [user, setUser] = useState<User | null>(null);
    const [allUsers, setAllUsers] = useState<User[]>([]);
    useEffect(() => {
        const getMessages = async () => {
            const response = await axios.get('/api/Account/me');
            console.log(response?.data);
            setUser(response?.data);
        }
        const getAllUsers = async () => {
            const response = await axios.get('/api/Account/all');
            console.log(response?.data);
            setAllUsers(response?.data);
        }
        const getGroups = async () => {
            const response = await axios.get('/api/Group/mygroups');
            console.log("test");
            console.log(response?.data);
            console.log("test")
            setGroups(response?.data);
        }
        getMessages();
        getAllUsers();
        getGroups();
        
    }, []);

    const getMessages = async () => {
        const response = await axios.get(`/api/Message/group/${group?.id}`);
        console.log(response?.data);
        setMessages(response?.data);
    }
    
    useEffect(() => {
        const getGroupUsers = async () => {
            const response = await axios.get(`/api/Group/${group?.id}`);
            console.log("test");
            console.log(response?.data);
            console.log("test");
            setGroupUsers(response?.data.users);
        }
        getGroupUsers();
        getMessages();
    }, [group]);

    useEffect(() => {
        const addMessage = async () => {
            const response = await axios.post(`/api/Message`, {
                content: messages[messages.length - 1].content,
                groupId: group?.id
            });
            console.log(response?.data);
        }
    }, [messages]);
    
    const  handleGroupChange = (group: Group) => {
        setGroup(group);
        console.log(messages);
    }
    
    const handleMessagesChange = async (content: string) => {
        const response = await axios.post(`/api/Message/send`, {
            content: content,
            groupId: group?.id
        });
        console.log(response?.data);
        await getMessages();
    }
    
    const [toggleGroup, setToggleGroup] = useState(false);
    const handleToggleGroup = (e:any) => {
        e.preventDefault();
        setAddUserToGroup(false);
        //remove user from all users
        allUsers.forEach((userr:User, index:number) => {
            if (userr.id === user?.id) {
                allUsers.splice(index, 1);
            }
        });
        setToggleGroup(!toggleGroup);
    }

    const findUsername = (id:string) => {
        let username = "";
        allUsers.forEach((user) => {
                if (user.id === id) {
                    username = user.username;
                }
            }
        );
        return username;
    };
    
    const [userId, setUserId] = useState<string>("");
    const [userName, setUserName] = useState<string>("");

    useEffect(() => {
        console.log("wchodzi cos?")
        setUserName(findUsername(userId));
    }, [userId]);
    
    const handleAdding = async (e:any) => {
        e.preventDefault();

        const response = await axios.post(`/api/Group/create`, {
            userId: user?.id,
            name: groupName,
            otherUserId: userId
        });
        console.log(response?.data);
        setToggleGroup(false);
        setIsUserId(false);
        setGroupName("");
        setUserId("");
        setUserName("");
        const getGroups = async () => {
            const response = await axios.get('/api/Group/mygroups');
            console.log("test");
            console.log(response?.data);
            console.log("test")
            setGroups(response?.data);
        }
        getGroups();
    }
    
    const [groupName, setGroupName] = useState<string>("");
    const [isUserId, setIsUserId] = useState<boolean>(false);
    
    const [addUserToGroup, setAddUserToGroup] = useState<boolean>(false);
    const toggleAddUserToGroup = (e:any) => {
        e.preventDefault();
        filterusers();
        setAddUserToGroup(!addUserToGroup);
        console.log(addUserToGroup);
    }
    
    const handleAddToGroup = async (e:any) => {
        e.preventDefault();
        const response = await axios.post(`/api/Group/adduser`, {
            groupId: group?.id,
            userId: userId
        });
        console.log(response?.data);
        setAddUserToGroup(false);
        setIsUserId(false);
        setUserId("");
        setUserName("");
        const getGroups = async () => {
            const response = await axios.get('/api/Group/mygroups');
            console.log("test");
            console.log(response?.data);
            console.log("test")
            setGroups(response?.data);
        }
        getGroups();
        const getGroupUsers = async () => {
            const response = await axios.get(`/api/Group/${group?.id}`);
            console.log("test");
            console.log(response?.data);
            console.log("test");
            setGroupUsers(response?.data.users);
        }
        getGroupUsers();
    }
    const [usersforGroup, setUsersForGroup] = useState<User[]>([]);
    const filterusers = () => {
        let users:User[] = [];
        //add to users all users that are not in group
        allUsers.forEach((user) => {
            let is = true;
            groupUsers.forEach((groupUser) => {
                if (groupUser.id === user.id) {
                    is = false;
                }
            });
            if (is) {
                users.push(user);
            }
        }
        );
        setUsersForGroup(users);
    };
    
    return (
        <>
            {!toggleGroup ? 
        <div className="main-box">
            <Groups username={user?.username} handleGroupChange={handleGroupChange} groups={groups}/>
            {group &&<> 
            <Messages groupName={group.name} groupUsers={groupUsers} handleMessagesChange={handleMessagesChange} messages={messages}></Messages>
            </>}
        </div> :
        <div className="main-box">
            <div style={{width:"50%"}}>
            <h1>Dodaj grupe</h1>
            <form>
                <input type="text" value={groupName} onChange={(e)=>setGroupName(e.target.value)} placeholder="Nazwa grupy" />
                <input type="text" disabled value={userName} placeholder="Użytkownik" />
                <button disabled={!isUserId || groupName.trim().length==0} onClick={handleAdding}>Dodaj</button>
            </form>
            </div>
            <AllUserList setIsUserId={setIsUserId} setUserId={setUserId} users={allUsers}></AllUserList>
        </div>
            }
            <div style={{display:"flex",flexDirection:"column"}}>
            <button onClick={handleToggleGroup}>{toggleGroup?"Ukryj dodawanie grupy":"Dodaj grupe"}</button>
                {group && <button onClick={toggleAddUserToGroup} >{!addUserToGroup ? "Dodaj do grupy":"Nie dodawaj do grupy"}</button>}
                {addUserToGroup && <>
                    <button onClick={handleAddToGroup}>Dodaj użytkownika do grupy</button>
                    <AllUserList setIsUserId={setIsUserId} setUserId={setUserId} users={usersforGroup}></AllUserList>
                </>}
            </div>
        </>
    );
};

export default Main;