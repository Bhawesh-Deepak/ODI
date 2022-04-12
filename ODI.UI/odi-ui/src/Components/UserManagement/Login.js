import React, { useState } from 'react';
import ModalPopUp from '../Common/ModalPopUp';
import Register from './Register';
import axios from 'axios';
import { Form, Field, ErrorMessage, Formik } from 'formik'
import * as Yup from 'yup'
import Submitbutton from '../Common/SubmitButton';
import { authenticate, baseUrl } from '../../Helpers/UrlHelper';
import { toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'


toast.configure()

const Login = (props) => {

    const [userDetail, setUserDetails] = useState({})

    const initialValues = {
        userName: '',
        password: ''
    }

    const validationScheme = Yup.object({
        userName: Yup.string().required("User name is required !"),
        password: Yup.string().required("Password is required !")
    })

    const HandleSubmit = async (values) => {
        setisLoading(true)
        await axios.post(baseUrl + authenticate, values).then(resp => {
            setUserDetails(resp.data.userDetails)
            debugger
            window.localStorage.setItem('UserDetail', JSON.stringify(resp.data.userDetails))
            window.localStorage.setItem('isLogged', true);
            window.location.href = '/dashboard'
        }).catch(err => {
            toast.error("Invalid User Name or password !")
            console.log(err)
        }).finally(() => {
            setisLoading(false)
        })
    }
    const [isLoading, setisLoading] = useState(false);
    return (
        <>
            <div className="login-box">
                <div className="login-logo">
                    <a style={{ "color": "white" }}>
                        <b>ODI-</b>Developers
                    </a>
                </div>
                {/* /.login-logo */}
                <div className="login-box-body">
                    <p className="login-box-msg">Sign in to start your session</p>
                    <Formik initialValues={initialValues}
                        validationSchema={validationScheme} onSubmit={HandleSubmit}>
                        <Form>
                            <div className="form-group has-feedback">
                                <Field type="text" name='userName' id='userName' className="form-control" placeholder="User Name" />
                                <ErrorMessage name='userName'>
                                    {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                </ErrorMessage>
                            </div>
                            <div className="form-group has-feedback">
                                <Field
                                    type="password"
                                    name='password'
                                    className="form-control"
                                    placeholder="Password"
                                />
                                <ErrorMessage name='password'>
                                    {(msg) => <span style={{ color: 'red' }}>{msg}</span>}
                                </ErrorMessage>
                            </div>
                            <div className="row">
                                <div className="col-xs-12">
                                    <Submitbutton loading={isLoading}></Submitbutton>
                                </div>
                            </div>
                        </Form>
                    </Formik>

                    <div className="social-auth-links text-center">
                        <p>- OR -</p>
                        <a onClick={() => props.register(true)} className="btn btn-block btn-social btn-facebook btn-flat">
                            <i className='fa fa-user' /> Register new User
                        </a>
                        <a
                            href="#"
                            className="btn btn-block btn-social btn-google-plus btn-flat"
                        >
                            <i className='fa fa-lock' /> Forget Password
                        </a>
                    </div>

                </div>

            </div>

        </>

    );
}

export default Login;
