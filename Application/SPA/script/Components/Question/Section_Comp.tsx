import React from "react";
import Section from '../../Models/Section';

export default class Section_Comp extends React.Component<Section> {
    constructor(props: Section) {
        super(props);
    }
    render() {
        return <div>{this.props.Text}</div>
    }
}