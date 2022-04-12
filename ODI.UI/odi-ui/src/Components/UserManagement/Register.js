import React, { useState, useEffect } from 'react';
import * as Yup from 'yup'
import { Form, Formik, ErrorMessage, Field } from 'formik'

const initialValues = {
    firstName: '',
    lastName: '',
    emailId: '',
    mobileNumber: '',
    companyId: '',
    claimHeadId: '',
    userCode: '',
    isCarporateDebtor: '',
    isAcceptTermCondition: '',
    password: ''

}



const Register = () => {
    return (
        <>
            <div className="register-box">
                <div className="register-logo">
                    <a href="../../index2.html">
                        <b>Admin</b>LTE
                    </a>
                </div>
                <div className="register-box-body">
                    <p className="login-box-msg">Register a new membership</p>
                    <Formik initialValues={initialValues}>
                        <Form>
                            <div className="form-group has-feedback">
                                <input type="text" className="form-control" placeholder="Full name" />
                                <span className="glyphicon glyphicon-user form-control-feedback" />
                            </div>
                            <div className="form-group has-feedback">
                                <input type="text" className="form-control" placeholder="Email" />
                                <span className="glyphicon glyphicon-envelope form-control-feedback" />
                            </div>
                            <div className="form-group has-feedback">
                                <input
                                    type="password"
                                    className="form-control"
                                    placeholder="Password"
                                />
                                <span className="glyphicon glyphicon-lock form-control-feedback" />
                            </div>
                            <div className="form-group has-feedback">
                                <input
                                    type="password"
                                    className="form-control"
                                    placeholder="Retype password"
                                />
                                <span className="glyphicon glyphicon-log-in form-control-feedback" />
                            </div>
                            <div className="row">
                                <div className="col-xs-8">
                                    <div className="checkbox icheck">
                                        <label>
                                            <input type="checkbox" /> I agree to the <a href="#">terms</a>
                                        </label>
                                    </div>
                                </div>
                                {/* /.col */}
                                <div className="col-xs-4">
                                    <button
                                        type="submit"
                                        className="btn btn-primary btn-block btn-flat"
                                    >
                                        Register
                                    </button>
                                </div>
                            </div>
                        </Form>
                    </Formik>

                </div>
            </div>
        </>

    );
}

export default Register;
