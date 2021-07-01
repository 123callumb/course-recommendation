import { Box, Divider, Stack, Text, Radio, RadioGroup, GridItem, Grid, SimpleGrid } from "@chakra-ui/react";
import React from "react";
import Answer from "../../Models/Answer";
import Section from '../../Models/Section';

export default class Section_Comp extends React.Component<Section> {
    constructor(props: Section) {
        super(props);
    }

    // More than one question for the section
    MultiQuestion() {
        const ansCount = this.props.Answers.length;
        const quesCount = this.props.Questions.length;

        return <>
            <SimpleGrid mt="3" columns={ansCount + 1}>
                <Box />
                {this.props.Answers.map((e, i) => <Box key={i} textAlign="center">{e.Text}</Box>)}
            </SimpleGrid>
            {this.props.Questions.map((e, i) => {
                return <RadioGroup key={i}>
                    <SimpleGrid columns={ansCount + 1}>
                        <Box >{e.Text}</Box>
                        {this.props.Answers.map((r, ind) => <Box key={ind + "" + i} textAlign="center" pt="4"><Radio size="md" value={r.AnswerID} /></Box>)}
                    </SimpleGrid>
                </RadioGroup>
            })}
        </>;
    }

    // The section title acts as the question
    SingleQuestion() {
        return <RadioGroup>
            <Stack spacing="3" mt="3">
                {this.props.Answers.map(e => <Radio size="md" key={e.AnswerID} value={e.AnswerID}>{e.Text}</Radio>)}
            </Stack>
        </RadioGroup>;
    }

    render() {
        return <Box p="4" bg="white" boxShadow="md" mt="6">
            <Box textAlign="left">
                <Text fontSize="xl">{this.props.Text}</Text>
                <Divider orientation="horizontal" mt="2" />
                {this.props.Questions.length > 0 ? this.MultiQuestion() : this.SingleQuestion()}
            </Box>
        </Box>;
    }
}