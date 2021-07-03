import { Box, Divider, Stack, Text, Radio, RadioGroup, GridItem, Grid, SimpleGrid, Fade } from "@chakra-ui/react";
import React from "react";
import Section from '../../Models/Section';
import { AnswerSet } from "../../Store/AnswerStore";
import MultiRadioQuestion from "../Question/MultiRadioQuestion";
import SingleRadioQuestion from "../Question/SingleRadioQuestion";

interface SectionComp_Props {
    section: Section;
    sectionAnswers: AnswerSet[];
}

export default class Section_Comp extends React.Component<SectionComp_Props> {
    constructor(props: SectionComp_Props) {
        super(props);
    }

    MultiQuestion() {
        return <MultiRadioQuestion answers={this.props.section.Answers} answerSet={this.props.sectionAnswers} questions={this.props.section.Questions} sectionID={this.props.section.SectionID} />;
    }

    SingleQuestion() {
        return <SingleRadioQuestion answers={this.props.section.Answers} answerSet={this.props.sectionAnswers.length > 0 ? this.props.sectionAnswers[0] : null} sectionID={this.props.section.SectionID} />;
    }

    render() {
        return <Fade in={true}>
            <Box p="4" bg="white" boxShadow="md" mt="6">
                <Box textAlign="left">
                    <Text fontSize="xl">{this.props.section.Text}</Text>
                    <Divider orientation="horizontal" mt="2" />
                    {this.props.section.Questions.length > 0 ? this.MultiQuestion() : this.SingleQuestion()}
                </Box>
            </Box>
        </Fade>;
    }
}