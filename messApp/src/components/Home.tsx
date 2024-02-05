const Home = () => {
    return (
        <div>
            <section>
                <p>
                    Nie masz jeszcze konta?<br />
                    <span className="line">
                            {/*put router link here*/}
                        <a href="http://localhost:5173/Register">Rejestracja</a>
                        </span>
                </p>
                <p>
                    masz już konto?<br />
                    <span className="line">
                            {/*put router link here*/}
                        <a href="http://localhost:5173/Login">Logowanie</a>
                        </span>
                </p>
            </section>
        </div>
    );
};

export default Home;