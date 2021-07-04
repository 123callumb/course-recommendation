import { Box, Radio, RadioGroup, SimpleGrid, Stack } from "@chakra-ui/react";
import React from "react";
import { connect } from "react-redux";
import Answer from "../../Models/Answer";
import { Question } from "../../Models/Question";
import { AnswerSet, SetAnswerSet } from "../../Store/AnswerStore";
import { AppState } from "../../Store/reducer";

interface MultiRadioComp_Props {
    sectionID: number;
    answers: Answer[];
    questions: Question[];
    answerSet: AnswerSet[];
    SetAnswerSet?: typeof SetAnswerSet;
}

class MultiRadioQuestion_Comp extends React.Component<MultiRadioComp_Props> {
    constructor(props: MultiRadioComp_Props) {
        super(props);
    }

    GetAnswerForQuestion(questionID: number) {
        return this.props.answerSet.find(f => f.QuestionID === questionID)?.AnswerID.toString();
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
                return <RadioGroup key={this.props.sectionID + "_" + i} value={this.GetAnswerForQuestion(e.QuestionID)} onChange={(newVal: string) => this.props.SetAnswerSet(this.props.sectionID, parseInt(newVal), e.QuestionID) }>
                    <SimpleGrid columns={ansCount + 1}>
                        <Box >{e.Text}</Box>
                        {this.props.answers.map((r, ind) =>
                            <Box key={ind + "" + i} textAlign="center" pt="4">
                                <Radio size="md" value={r.AnswerID.toString()} />
                            </Box>)}
                    </SimpleGrid>
                </RadioGroup>
            })}
        </>;
    }
}

export default connect((state: AppState, props: MultiRadioComp_Props): MultiRadioComp_Props => ({
    ...props
}), {
    SetAnswerSet
})(MultiRadioQuestion_Comp);