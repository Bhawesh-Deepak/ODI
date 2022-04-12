import React from 'react';

const Sidebar = () => {
    return (
        <aside className="main-sidebar">
            {/* sidebar: style can be found in sidebar.less */}
            <section className="sidebar">
                {/* Sidebar user panel */}
                <div className="user-panel">
                    <div className="pull-left image">
                        <img
                            src="../../dist/img/user2-160x160.jpg"
                            className="img-circle"
                            alt="User Image"
                        />
                    </div>
                    <div className="pull-left info">
                        <p>Alexander Pierce</p>
                        <a href="#">
                            <i className="fa fa-circle text-success" /> Online
                        </a>
                    </div>
                </div>
                <ul className="sidebar-menu">
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-dashboard" /> <span>Dashboard</span>{" "}
                            <i className="fa fa-angle-left pull-right" />
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../../index.html">
                                    <i className="fa fa-circle-o" /> Dashboard v1
                                </a>
                            </li>
                            <li>
                                <a href="../../index2.html">
                                    <i className="fa fa-circle-o" /> Dashboard v2
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-files-o" />
                            <span>Layout Options</span>
                            <span className="label label-primary pull-right">4</span>
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../layout/top-nav.html">
                                    <i className="fa fa-circle-o" /> Top Navigation
                                </a>
                            </li>
                            <li>
                                <a href="../layout/boxed.html">
                                    <i className="fa fa-circle-o" /> Boxed
                                </a>
                            </li>
                            <li>
                                <a href="../layout/fixed.html">
                                    <i className="fa fa-circle-o" /> Fixed
                                </a>
                            </li>
                            <li>
                                <a href="../layout/collapsed-sidebar.html">
                                    <i className="fa fa-circle-o" /> Collapsed Sidebar
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="../widgets.html">
                            <i className="fa fa-th" /> <span>Widgets</span>{" "}
                            <small className="label pull-right bg-green">Hot</small>
                        </a>
                    </li>
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-pie-chart" />
                            <span>Charts</span>
                            <i className="fa fa-angle-left pull-right" />
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../charts/morris.html">
                                    <i className="fa fa-circle-o" /> Morris
                                </a>
                            </li>
                            <li>
                                <a href="../charts/flot.html">
                                    <i className="fa fa-circle-o" /> Flot
                                </a>
                            </li>
                            <li>
                                <a href="../charts/inline.html">
                                    <i className="fa fa-circle-o" /> Inline charts
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-laptop" />
                            <span>UI Elements</span>
                            <i className="fa fa-angle-left pull-right" />
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../UI/general.html">
                                    <i className="fa fa-circle-o" /> General
                                </a>
                            </li>
                            <li>
                                <a href="../UI/icons.html">
                                    <i className="fa fa-circle-o" /> Icons
                                </a>
                            </li>
                            <li>
                                <a href="../UI/buttons.html">
                                    <i className="fa fa-circle-o" /> Buttons
                                </a>
                            </li>
                            <li>
                                <a href="../UI/sliders.html">
                                    <i className="fa fa-circle-o" /> Sliders
                                </a>
                            </li>
                            <li>
                                <a href="../UI/timeline.html">
                                    <i className="fa fa-circle-o" /> Timeline
                                </a>
                            </li>
                            <li>
                                <a href="../UI/modals.html">
                                    <i className="fa fa-circle-o" /> Modals
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-edit" /> <span>Forms</span>
                            <i className="fa fa-angle-left pull-right" />
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../forms/general.html">
                                    <i className="fa fa-circle-o" /> General Elements
                                </a>
                            </li>
                            <li>
                                <a href="../forms/advanced.html">
                                    <i className="fa fa-circle-o" /> Advanced Elements
                                </a>
                            </li>
                            <li>
                                <a href="../forms/editors.html">
                                    <i className="fa fa-circle-o" /> Editors
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li className="treeview">
                        <a href="#">
                            <i className="fa fa-table" /> <span>Tables</span>
                            <i className="fa fa-angle-left pull-right" />
                        </a>
                        <ul className="treeview-menu">
                            <li>
                                <a href="../tables/simple.html">
                                    <i className="fa fa-circle-o" /> Simple tables
                                </a>
                            </li>
                            <li>
                                <a href="../tables/data.html">
                                    <i className="fa fa-circle-o" /> Data tables
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="../calendar.html">
                            <i className="fa fa-calendar" /> <span>Calendar</span>
                            <small className="label pull-right bg-red">3</small>
                        </a>
                    </li>


                </ul>
            </section>
            {/* /.sidebar */}
        </aside>


    );
}

export default Sidebar;
