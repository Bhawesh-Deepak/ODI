<<<<<<< .mine
import React from 'react';

const Submitbutton = (props) => {
    return (
        <>

            <div className="box-footer">
                {
                    !props.loading ? (<button type="submit" className="btn btn-primary pull-right">
                        Submit
                    </button>) : (<button disabled='disabled' class="btn  btn-primary pull-right">
                        <i class="fa fa-spinner fa-spin"></i>Please wait...
                    </button>)
                }
            </div>
        </>
    );
}

export default Submitbutton;
=======
import React from 'react';

const Submitbutton = (props) => {
    return (
        <>

            <div className="box-footer">
                {
                    !props.loading ? (<button type="submit" className="btn btn-primary">
                        Submit
                    </button>) : (<button disabled='disabled' class="btn  btn-primary">
                        <i class="fa fa-spinner fa-spin"></i>Please wait...
                    </button>)
                }
            </div>
        </>
    );
}

export default Submitbutton;
>>>>>>> .theirs
