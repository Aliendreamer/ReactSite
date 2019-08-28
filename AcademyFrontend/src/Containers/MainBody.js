import React,{Component} from 'react';
import Form from '../Components/CoursesForm';
import CourseSlider from '../Components/Courses';
class MainBody extends Component{

    render(){
        return(
            <div>
                <div>
                    first div
                </div>
                <div>
                    <Form/>
                </div>
                <div>
                   <CourseSlider/>
                </div>
                <div>
                    fourth div
                </div>
            </div>
        )
    }
}
export default MainBody;