import { Box, Radio, RadioGroup, SimpleGrid, Stack } from "@chakra-ui/react";
import React from "react";
import Answer from "../../Models/Answer";
import { Question } from "../../Models/Question";
import { AnswerSet } from "../../Store/AnswerStore";

interface MultiRadioComp_Props {
    sectionID: number;
    answers: Answer[];
    questions: Question[];
    answerSet: AnswerSet[];
}

export default class MultiRadioQuestion_Comp extends React.Component<MultiRadioComp_Props> {
    constructor(props: MultiRadioComp_Props) {
        super(props);
    }

    render() {
        const ansCount = this.props.answers.length;
        const quesCount = this.props.questions.length;

        return <>
            <SimpleGrid mt="3" columns={ansCount + 1}>
                <Box />
                {this.props.answers.map((e, i) => <Box key={i} textAlign="center">{e.Text}</Box>)}
            </SimpleGrid>
            {this.props.questions.map((e, i) => {
                return <RadioGroup key={i}>
                    <SimpleGrid columns={ansCount + 1}>
                        <Box >{e.Text}</Box>
                        {this.props.answers.map((r, ind) => <Box key={ind + "" + i} textAlign="center" pt="4"><Radio size="md" value={r.AnswerID} /></Box>)}
                    </SimpleGrid>
                </RadioGroup>
            })}
        </>;
    }
}