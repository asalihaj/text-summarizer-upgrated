import React, { Component } from 'react';
import axios from 'axios';
import { Container, Form, FormGroup, Input, Button} from 'reactstrap';
import './Home.css';

const baseURL = `http://localhost:58851/api/`;


export class Home extends Component {
    static displayName = Home.name;
    summarize = async () => {
        const text = document.querySelector("#user-text").value;
        const data = { text: text, type: "extractive" };
        let summary = await axios.post(`${baseURL}summary`, { content: text, type: "extractive"});
        document.querySelector("#summary-text").value = summary.data;
    }

  render () {
    return (
        <div className="">
            <Container>
                <Form>
                    <FormGroup className="summary-fields">
                        <Input
                            id="user-text"
                            name="text"
                            type="textarea"
                            placeholder="Write here..."
                            />
                        <Input
                            id="summary-text"
                            name="text"
                            type="textarea"
                            placeholder="Summarized text appears here..."
                            disabled
                        />
                        
                    </FormGroup>
                    <FormGroup className="control-buttons">
                        <Button
                            type="submit"
                            color="primary"
                            size="sm"
                            outline
                            id="copy"
                            onClick={(event) => {
                                event.preventDefault();
                                const copyText = document.querySelector("#summary-text");
                                navigator.clipboard.writeText(copyText.value);
                                alert("Summary copied to clipboard");
                            }}
                        >
                            Copy
                        </Button>
                        <Button
                            type="submit"
                            id="clear"
                            color="primary"
                            size="sm"
                            onClick={(event) => {
                                event.preventDefault();
                                document.querySelector("#summary-text").value = "";
                            }}
                        >
                            Clear
                        </Button>
                    </FormGroup>
                    <FormGroup className="summarize">
                        <Button
                            type="submit"
                            color="primary"
                            onClick={(event) => {
                                event.preventDefault();
                                this.summarize()
                            }}
                        >
                            Summarize
                        </Button>
                    </FormGroup>
                </Form>
            </Container>
        </div>
    );
  }
}

/*
 <div>
            <form className="summary">
                <div className="summary-header">
                </div>
                <div className="summary-content">
                    <div className="user-text">
                        <textarea className="user-input" placeholder="Write here"></textarea>
                    </div>
                    <div id="summarization" className="summary-text">
                        <textarea className="user-input" placeholder="Summary..."></textarea>
                    </div>
                </div>
                <div className="submit-form">
                    <button className="submit">Summarize</button>
                </div>
            </form>
      </div>
 */
