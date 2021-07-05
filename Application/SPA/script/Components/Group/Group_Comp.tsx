﻿import { Box, Heading, Text } from "@chakra-ui/react";
import React from "react";
import Group from "../../Models/Responses/Group";
import { AnswerSet } from "../../Store/AnswerStore";
import Section_Comp from "../Section/Section_Comp";

interface GroupComp_Props {
    Group: Group;
    AnswerSets: AnswerSet[];
}

export default class Group_Comp extends React.Component<GroupComp_Props> {
    constructor(props: GroupComp_Props) {
        super(props);
    }

    GetSectionAnswerSet(sectionID: number) {
        return this.props.AnswerSets.filter(f => f.SectionID === sectionID);
    }

    render() {
        console.log(this.props.AnswerSets);
        return (<>
            <Box>
                <Heading size="lg">{this.props.Group.Name}</Heading>
                <Text size="md">{this.props.Group.Description}</Text>
            </Box>
            {this.props.Group.Sections.map(e => <Section_Comp key={e.SectionID} section={e} sectionAnswers={this.GetSectionAnswerSet(e.SectionID)} groupID={this.props.Group.GroupID} />)}
        </>);
    }
}