import React, { useState, useEffect } from 'react';
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.min.css';
import './Home.css';

const Home = () => {

    const [bookmarkCounter, setBookmarkCounter] = useState([]);

    useEffect(() => {
        const loadTop5 = async () => {
            const { data } = await axios.get('/api/bookmark/gettop5')
            setBookmarkCounter(data)
        }
        loadTop5()
    }, [])



    return (
        <div className="container" style={{ marginTop: "80px" }}>
            <main role="main" className="pb-3">
                <div>
                    <h1>Welcome to the React Bookmark Application.</h1>
                    <h3>Top 5 most bookmarked links</h3>
                    <table className="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>URL</th>
                                <th>Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {bookmarkCounter.map(b => <tr>
                                <td>
                                    <a href={b.bookmark.url} target="_blank">{b.bookmark.url}</a>
                                </td>
                                <td>{b.userCount}</td>
                            </tr>)}
                        </tbody>
                    </table>
                </div>
            </main>
        </div>
    )
}

export default Home;