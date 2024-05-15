import React, { useState } from 'react'
import axios from 'axios'
import { useAuthentication } from '../AuthenticationContext'
import { useNavigate } from 'react-router-dom'

const AddBookmark = () => {

    const [form, setForm] = useState({
        title: '',
        url: ''
    })

    const { user } = useAuthentication()
    const userId = user.id
    const navigate = useNavigate()


    const onTextChange = e => {
        const copy = { ...form }
        copy[e.target.name] = e.target.value
        setForm(copy)
        console.log(userId)
    }

    const onFormSubmit = async e => {
        e.preventDefault()
        const body = {
            bookmark: {
                title: form.title,
                url: form.url
            },
            userId: userId
        }
        await axios.post('/api/bookmark/addbookmark', body)
        navigate('/mybookmarks')
    }


    return (
        <div className='container' style={{ marginTop: '80px' }}>
            <main role='main' className='pb-3'>
                <div className='row' style={{ minHeight: '80vh', display: 'flex', alignItems: 'center' }}>
                    <div className='col-md-6 offset-md-3 bg-light p-4 rounded shadow'>
                        <h3>Add a Bookmark</h3>
                        <form>
                            <input type="text" name="title" placeholder="Title" className="form-control" value={form.title} onChange={onTextChange}></input>
                            <br></br>
                            <input type="text" name="url" placeholder="Url" className="form-control" value={form.url} onChange={onTextChange}></input>
                            <br></br>
                            <button className="btn btn-primary" onClick={onFormSubmit}>Add</button>
                        </form>
                    </div>
                </div>
            </main>
        </div>)
}

export default AddBookmark