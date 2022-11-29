import React from 'react'
import IPerson from '../model/IPerson'
import './PersonView.css'

export class PersonView extends React.Component<IPerson>
{
    render(){
        return(
            <div className='person-view'>
                <div className='person-view-element'>
                    <label className='person-view-label'>First Name: </label>
                    <span className='person-view-label'>{this.props.firstName}</span>
                </div>
                <div className='person-view-element'>
                    <label className='person-view-label'>Last Name: </label>
                    <span className='person-view-label'>{this.props.lastName}</span>
                </div>
            </div>
        );
    }
}