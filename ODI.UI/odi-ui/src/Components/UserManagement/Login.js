import React, { useState } from 'react';
import ModalPopUp from '../Common/ModalPopUp';
import Register from './Register';

const Login = (props) => {

    return (
        <>
            <div className="login-box">
                <div className="login-logo">
                    <a href="../../index2.html" style={{ "color": "white" }}>
                        <b>ODI-</b>Developers
                    </a>
                </div>
                {/* /.login-logo */}
                <div className="login-box-body">
                    <p className="login-box-msg">Sign in to start your session</p>
                    <form action="../../index2.html" method="post">
                        <div className="form-group has-feedback">
                            <input type="text" className="form-control" placeholder="User Name" />
                            <span className="glyphicon glyphicon-user form-control-feedback" />
                        </div>
                        <div className="form-group has-feedback">
                            <input
                                type="password"
                                className="form-control"
                                placeholder="Password"
                            />
                            <span className="glyphicon glyphicon-lock form-control-feedback" />
                        </div>
                        <div className="row">
                            <div className="col-xs-8">
                                <div className="checkbox icheck">
                                    <label>
                                        <input type="checkbox" /> Remember Me
                                    </label>
                                </div>
                            </div>
                            {/* /.col */}
                            <div className="col-xs-4">
                                <button
                                    type="submit"
                                    className="btn btn-primary btn-block btn-flat"
                                >
                                    Sign In
                                </button>
                            </div>
                            {/* /.col */}
                        </div>
                    </form>
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
